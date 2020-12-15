using System;

namespace WorkersInfo.Entities
{
    public class Post:CountingEntity<Post>
    {
      
        public string StringIdentifier
        {
            get
            {
                return Name;
            }
        }
        private string name;
        private string code;
        private int? state_units;
        public string Notice { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Назва посади не може бути пуста", name);
                }
                value = value.Trim();
                if (value.Length < 3 || value.Length > 40)
                {
                    throw new FormatException("Назва має містити від 3 до 40 символів");
                }
                name = value;
            }
        }
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                if (value != null&&value.Length != 5)
                {
                    throw new FormatException("Код посади має складатись з 5-ти символів");
                }
                code = value;
            }
        }
        public int? State_Units
        {
            get
            {
                return state_units;
            }
            set
            {
                if (value != null&value <= 0)
                {
                    throw new FormatException("Кількість штатних одиниць повинна бути більша 0");
                }
                state_units = value;
            }
        }      
        public Post(string name, string code, int? state_units)
        {
            Name = name;
            Code = code;
            State_Units = state_units;
        }
        public Post(string name) : this(name, null, null) { }
        public Post() { }
    }
}
