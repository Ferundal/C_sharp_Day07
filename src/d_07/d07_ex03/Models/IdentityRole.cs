using System.ComponentModel;

namespace d07_ex03.Models
{
    public class IdentityRole
    {
        public IdentityRole()
        {
        }

        [Description("Role Name")]
        [DefaultValue("Woker")]
        public string Name { get; set; }
        [Description("Role Description")]
        [DefaultValue("It is not much but it is good work!")]
        public string Description { get; set; }

        public override string ToString()
            => $"{Name}, {Description}";
    }
}