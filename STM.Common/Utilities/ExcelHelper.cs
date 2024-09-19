namespace STM.Common.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    public static class ExcelHelper
    {
        /// <summary>
        /// Tạo combobox trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="columnName">Tên cột cần fill.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="totalRow">Tổng số hàng muốn fill.</param>
        /// <param name="listValue">Danh sách dữ liệu cần fill.</param>
        public static void HandleComboboxExcel(this ExcelWorksheet sheet, string columnName, int startRow, int totalRow, List<string> listValue)
        {
            if (startRow > 0 && listValue.Count > 0)
            {
                for (int i = 0; i <= totalRow; i++)
                {
                    var val = sheet.DataValidations.AddListValidation(columnName + (startRow + i));
                    for (int j = 0; j < listValue.Count; j++)
                    {
                        val.Formula.Values.Add(listValue[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Tạo combobox dùng range data trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="columnName">Tên cột cần fill.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="totalRow">Tổng số hàng muốn fill.</param>
        /// <param name="formulaRangeData">Formula của range chứa dữ liệu.</param>
        public static void HandleComboboxExcel(this ExcelWorksheet sheet, string columnName, int startRow, int totalRow, string formulaRangeData)
        {
            for (int i = 0; i <= totalRow; i++)
            {
                var val = sheet.DataValidations.AddListValidation(columnName + (startRow + i));
                val.Formula.ExcelFormula = formulaRangeData;
            }
        }

        /// <summary>
        /// Kẻ border trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="startColumn">Cột bắt đầu.</param>
        /// <param name="endRow">Hàng kết thúc.</param>
        /// <param name="endColumn">Cột kết thúc.</param>
        /// <param name="style">Boder style.</param>
        public static void RenderBorderAll(this ExcelWorksheet sheet, int startRow, int startColumn, int endRow, int endColumn, ExcelBorderStyle style)
        {
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Top.Style = style;
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Left.Style = style;
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Right.Style = style;
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Bottom.Style = style;
        }

        /// <summary>
        /// Kẻ border top trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="startColumn">Cột bắt đầu.</param>
        /// <param name="endRow">Hàng kết thúc.</param>
        /// <param name="endColumn">Cột kết thúc.</param>
        /// <param name="style">Boder style.</param>
        public static void RenderBorderTop(this ExcelWorksheet sheet, int startRow, int startColumn, int endRow, int endColumn, ExcelBorderStyle style)
        {
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Top.Style = style;
        }

        /// <summary>
        /// Kẻ border bottom trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="startColumn">Cột bắt đầu.</param>
        /// <param name="endRow">Hàng kết thúc.</param>
        /// <param name="endColumn">Cột kết thúc.</param>
        /// <param name="style">Boder style.</param>
        public static void RenderBorderBottom(this ExcelWorksheet sheet, int startRow, int startColumn, int endRow, int endColumn, ExcelBorderStyle style)
        {
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Bottom.Style = style;
        }

        /// <summary>
        /// Kẻ border left trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="startColumn">Cột bắt đầu.</param>
        /// <param name="endRow">Hàng kết thúc.</param>
        /// <param name="endColumn">Cột kết thúc.</param>
        /// <param name="style">Boder style.</param>
        public static void RenderBorderLeft(this ExcelWorksheet sheet, int startRow, int startColumn, int endRow, int endColumn, ExcelBorderStyle style)
        {
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Left.Style = style;
        }

        /// <summary>
        /// Kẻ border right trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="startColumn">Cột bắt đầu.</param>
        /// <param name="endRow">Hàng kết thúc.</param>
        /// <param name="endColumn">Cột kết thúc.</param>
        /// <param name="style">Boder style.</param>
        public static void RenderBorderRight(this ExcelWorksheet sheet, int startRow, int startColumn, int endRow, int endColumn, ExcelBorderStyle style)
        {
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Border.Right.Style = style;
        }

        /// <summary>
        /// Convert FileInfo to Stream.
        /// </summary>
        /// <param name="excelPackage">Excel package.</param>
        /// <param name="newFile">FileInfo.</param>
        /// <returns>Stream.</returns>
        public static Stream? ToStream(this ExcelPackage excelPackage, FileInfo newFile)
        {
            if (excelPackage != null)
            {
                excelPackage.SaveAs(newFile);
                string fullPath = newFile.FullName;
                MemoryStream memoryStream;
                using (FileStream fileStream = File.OpenRead(fullPath))
                {
                    memoryStream = new MemoryStream();
                    memoryStream.SetLength(fileStream.Length);
                    fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                }

                FileInfo fi = new FileInfo(fullPath);
                fi.Delete();
                return memoryStream;
            }

            return null;
        }

        /// <summary>
        /// Returns the Excel file as a memory stream without saving file.
        /// </summary>
        /// <param name="excelPackage">Excel package.</param>
        /// <param name="file">FileInfo.</param>
        /// <returns>Stream.</returns>
        public static Stream? GetAsStream(this ExcelPackage excelPackage, FileInfo file)
        {
            if (excelPackage != null)
            {
                string fullPath = file.FullName;
                MemoryStream memoryStream;
                using (FileStream fileStream = File.OpenRead(fullPath))
                {
                    memoryStream = new MemoryStream();
                    memoryStream.SetLength(fileStream.Length);
                    fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                }

                return memoryStream;
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra cell có dữ liệu không.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="row">Vị trí hàng.</param>
        /// <param name="column">Vị trí cột.</param>
        public static bool IsCellNullOrWhiteSpace(this ExcelWorksheet sheet, int row, int column)
        {
            return sheet.GetValue(row, column) == null || string.IsNullOrWhiteSpace(sheet.GetValue(row, column)?.ToString());
        }

        /// <summary>
        /// Đánh dấu cell bị lỗi.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="row">Vị trí hàng.</param>
        /// <param name="column">Vị trí cột.</param>
        public static void MarkErrorCell(this ExcelWorksheet sheet, int row, int column)
        {
            sheet.Cells[row, column].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Red);
        }

        public static string GetColumnName(int orderColumn)
        {
            return ((char)(orderColumn + 65)).ToString();
        }

        /// <summary>
        /// Highlight trong excel.
        /// </summary>
        /// <param name="sheet">Sheet.</param>
        /// <param name="startRow">Hàng bắt đầu.</param>
        /// <param name="startColumn">Cột bắt đầu.</param>
        /// <param name="endRow">Hàng kết thúc.</param>
        /// <param name="endColumn">Cột kết thúc.</param>
        /// <param name="fillStyle">Fill style.</param>
        /// <param name="fillColor">Fill color.</param>
        public static void HighlightCells(this ExcelWorksheet sheet, int startRow, int startColumn, int endRow, int endColumn, ExcelFillStyle fillStyle, Color fillColor)
        {
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Fill.PatternType = fillStyle;
            sheet.Cells[startRow, startColumn, endRow, endColumn].Style.Fill.BackgroundColor.SetColor(fillColor);
        }

        public static void Merge(this ExcelWorksheet sheet, int row, int col, int row2, int col2)
        {
            sheet.SelectedRange[row, col, row2, col2].Merge = true;
        }

        /// <summary>
        /// Kiểm tra file excel có dữ liệu hay không.
        /// </summary>
        /// <param name="file">Form File.</param>
        /// <param name="firstDataRowIndex">Số thứ tự hàng dữ liệu đầu tiên.</param>
        public static bool HasNoData(this IFormFile file, int firstDataRowIndex = 2)
        {
            using (var pck = new ExcelPackage(file.OpenReadStream()))
            {
                var sheet = pck.Workbook.Worksheets[0];

                return sheet.IsEndFile(firstDataRowIndex);
            }
        }

        public static int ToColumnIndex(this string columnName)
        {
            var index = 0;
            var power = 0;
            for (int i = columnName.Length - 1; i >= 0; i--)
            {
                index += (int)((columnName[i] - 64) * Math.Pow(26, power));
                power++;
            }

            return index;
        }

        /// <summary>
        /// Kiểm tra điều kiện kết thúc file.
        /// </summary>
        /// <param name="sheet">Excel sheet.</param>
        /// <param name="currentRow">Số thứ tự hàng dữ liệu hiện tại.</param>
        public static bool IsEndFile(this ExcelWorksheet sheet, int currentRow)
        {
            for (int i = currentRow; i < currentRow + 10; i++)
            {
                if (sheet.GetValue(i, 1) != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
