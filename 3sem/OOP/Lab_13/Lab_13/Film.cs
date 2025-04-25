using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace lr_13
{
    public partial class TVProgramConteiner
    {
        private List<TVProgram> list;

        public TVProgramConteiner(List<TVProgram> list)
        {
            this.list = list;
        }

        public List<TVProgram> Conteiner
        {
            get => list;
            set => list = value;
        }
    }

    public enum ProgramCategory
    {
        Morning,
        Afternoon,
        Evening,
        Night,
    }

    [Serializable]
    public abstract class TVProgram
    {
        public abstract string Name { get; set; }
        [XmlIgnore]
        public abstract int Time { get; set; }

        public override string ToString()
        {
            return $"Программа: {Name}, Длительность: {Time} минут";
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is TVProgram program)
            {
                if (Name == program.Name && Time == program.Time)
                {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            int result = Name.GetHashCode() / 100;
            return result;
        }
        public abstract void ReturnName();
        public ProgramCategory TimeDay { get; set; }

    }
    [Serializable]
    public class Film : TVProgram
    {
        private string _name = "Фильм";
        public override string Name { get => _name; set => _name = value; }

        [NonSerialized]
        private int _time;

        [JsonIgnore]
        [XmlIgnore]
        public override int Time { get => _time; set => _time = value; }

        string _year = DateTime.Now.Year.ToString();

        public virtual string Year { get => _year; set => _year = value; }

        public override string ToString()
        {
            return base.ToString() + $" ,Год выпуска: {Year}";
        }
        public override void ReturnName() { }
        public Film()
        {
            TimeDay = ProgramCategory.Morning;
        }
    }
}

