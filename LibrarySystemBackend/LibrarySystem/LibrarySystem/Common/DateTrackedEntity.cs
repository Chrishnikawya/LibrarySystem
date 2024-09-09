namespace LibrarySystem.Common
{
    public class DateTrackedEntity : BaseEntity
    {
       public DateTime DateCreated { get; set; } = DateTime.Now;
       public DateTime DateModified { get; set; }
    }
}
