namespace STM.Services.Services
{
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.DataTranferObjects.Majors;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MajorService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<MajorDto>> Search(MajorSearchDto dto)
        {
            var queryMajor = await this._unitOfWork.GetRepositoryReadOnlyAsync<Major>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var nameSearch = dto.Name.Trim().ToLower();
                queryMajor = queryMajor.Where(x => x.Name.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                queryMajor = queryMajor.Where(x => x.Status == dto.Status);
            }

            var query = queryMajor.OrderBy(x => x.CreatedAt).Select(x => new MajorDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<MajorDto?> FindById(Guid id)
        {
            var queryMajor = await this._unitOfWork.GetRepositoryReadOnlyAsync<Major>().QueryAll();
            var major = queryMajor.FirstOrDefault(i => i.Id == id);

            if (major == null)
            {
                return null;
            }

            return new MajorDto
            {
                Id = major.Id,
                Name = major.Name,
                Status = major.Status,
                CreatedAt = major.CreatedAt,
                CreatedById = major.CreatedById,
                UpdatedAt = major.UpdatedAt,
                UpdatedById = major.UpdatedById,
            };
        }

        public async Task<string> Create(MajorSaveDto dto)
        {
            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();

            var newMajor = new Major
            {
                Name = dto.Name,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active.AsInt(),
            };

            await majorRep.Add(newMajor);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Major);
        }

        public async Task<string> Update(MajorSaveDto dto)
        {
            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();

            var major = await majorRep.Single(i => i.Id == dto.Id);

            if (major == null)
            {
                return Messages.NotFound;
            }

            major.Name = dto.Name;
            major.Status = dto.Status;

            await majorRep.Update(major);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Major);
        }

        public async Task<string> Delete(Guid id)
        {
            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();
            var major = await majorRep.Single(i => i.Id == id);

            if (major == null)
            {
                return Messages.NotFound;
            }

            await majorRep.Delete(major);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Major);
        }

        public MemoryStream ExportTemplate()
        {
            string templatePath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.TemplateFolder);
            string reportPath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.ReportFolder);
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            string fileName = string.Format(FileNameConstants.MajorFormat, DateTime.Now.ToString("yyyyMMddhhmmsss"));
            FileInfo newFile = new FileInfo(Path.Combine(reportPath, fileName));
            FileInfo templateFile = new FileInfo(Path.Combine(templatePath, FileNameConstants.MajorTemplate));

            using (ExcelPackage pck = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet sheet = pck.Workbook.Worksheets[0];

                var statuses = StatusConstants.StatusNames;

                sheet.HandleComboboxExcel("C", 3, 50, statuses);

                ExcelHelper.RenderBorderAll(sheet, 3, 2, 50, 4, ExcelBorderStyle.Thin);

                sheet.Name = "BC";
                var stream = new MemoryStream();
                pck.ToStream(newFile);
                pck.SaveAs(stream);
                return stream;
            }
        }

        public async Task<string> Import(MajorImportDto dto)
        {
            if (dto.File == null)
            {
                return Messages.FileEmpty;
            }

            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();

            using (var package = new ExcelPackage(dto.File.OpenReadStream()))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets[0];

                var rowCount = ws.Dimension.Rows;
                var colCount = ws.Dimension.Columns;

                var newMajors = new List<Major>();

                var rowsHasValue = this.FindRowsWithValue(ws);

                foreach (var rowNumber in rowsHasValue)
                {
                    var statusName = ws.Cells[$"C{rowNumber}"].Value.ToString();
                    newMajors.Add(new Major()
                    {
                        Name = ws.Cells[$"B{rowNumber}"].Value.ToString().Trim(),
                        Status = StatusConstants.GetStatusValue(statusName),
                    });
                }

                if (newMajors.Count > 0)
                {
                    await majorRep.Add(newMajors);
                    await this._unitOfWork.SaveChangesAsync();
                }
            }

            return string.Format(Messages.ImportSuccess, GlobalConstants.Menu.Major);
        }

        private IEnumerable<int> FindRowsWithValue(ExcelWorksheet worksheet)
        {
            var matchingRows = new List<int>();

            for (int row = 4; row <= worksheet.Dimension.End.Row; row++)
            {
                var name = worksheet.Cells[$"B{row}"].Text;
                var status = worksheet.Cells[$"C{row}"].Text;

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(status))
                {
                    matchingRows.Add(row);
                }
            }

            return matchingRows;
        }
    }
}
