using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverloadToString
{
    public partial class FrmTesting : Form
    {
        public FrmTesting()
        {
            InitializeComponent();
        }

        private void FrmTesting_Load(object sender, EventArgs e)
        {

        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            Student s1 = new Student("John", "Smith", "jts", 95, 80);
            Student s2 = new Student("Mary", "Jones", "msj", 95, 80);
            Student s3 = new Student("Craig", "Abbot", "ca", 95, 80);
            Student s4 = new Student("Mary", "Jones", "msj", 95, 80);

            LbxOutput.Items.Add(s1.ToString());
            LbxOutput.Items.Add(s2.ToString());
            LbxOutput.Items.Add(s3.ToString());
            LbxOutput.Items.Add(s4.ToString());
            LbxOutput.Items.Add("");

            LbxOutput.Items.Add($" s1 > s2 :{ s1 > s2}");
            LbxOutput.Items.Add($" s1 > s3 :{ s1 > s3}");
            LbxOutput.Items.Add("");
            LbxOutput.Items.Add($" s3 > s2 :{ s3 > s2}");
            LbxOutput.Items.Add($" s3 < s2 :{ s3 < s2}");
            LbxOutput.Items.Add("");
            LbxOutput.Items.Add($" s4 = s2 :{ s4 == s2}");
            LbxOutput.Items.Add($" s4 != s2 :{ s4 != s2}");
        }
    }

    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public int MathAvg { get; set; }
        public int SciAvg { get; set; }

        public Student(string firstName, string lastName, string initials, int mathAvg, int sciAvg)
        {
            FirstName = firstName;
            LastName = lastName;
            Initials = initials;
            MathAvg = mathAvg;
            SciAvg = sciAvg;
        }

        public override string ToString()
        {
            return $"{(FirstName + " " + LastName).LJ(13)}: {Initials.RJ(5)}   Math Avg: {MathAvg.RJ(5)}    Math Avg: {SciAvg.RJ(5)}";
        }

        public int CompareTo(Student other)
        {
            return string.Compare(this.LastName, other.LastName);
        }

        public static bool operator >(Student first, Student second)
        {
            return (first.CompareTo(second) > 0);
        }

        public static bool operator <(Student first, Student second)
        {
            return (first.CompareTo(second) < 0);
        }

        public static bool operator ==(Student first, Student second)
        {
            return (first.CompareTo(second) == 0);
        }

        public static bool operator !=(Student first, Student second)
        {
            return (first.CompareTo(second) != 0);
        }
    }






}
