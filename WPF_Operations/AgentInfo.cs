using System.ComponentModel;
namespace WPF_Operations
{
    public class AgentInfo:IDataErrorInfo
    {
        public virtual int AgentId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual string Mobile { get; set; }

        public virtual string Error
        {
            get
            {
                return this[string.Empty];
            }
        }

        public virtual string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(columnName))

                    {

                        return "Name Cannot be Empty.";

                    }
                }
                return null;
            }
        }
    }
}
