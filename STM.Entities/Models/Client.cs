namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Clients")]
    public class Client : BaseModel
    {
        public Guid ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Scope { get; set; }

        [NotMapped]
        public string[] ScopeArray
        {
            get
            {
                return !string.IsNullOrEmpty(this.Scope) ? this.Scope.Split(',') : new string[] { };
            }

            set
            {
                this.Scope = string.Join(",", value);
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
