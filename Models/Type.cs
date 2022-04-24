namespace Chemical_Management.Models
{
    public enum ReagentType { Organic, Inorganic, Acid, Base, Corrosive, Toxic }
    public class Type
    {
        public int Id { get; set; }
        public ReagentType Reagent_Type { get; set; } //enum for type of reagent
        public virtual ICollection<Reagent> Reagents { get; set; } //many reagents can have many types (m to m)
    }
}
