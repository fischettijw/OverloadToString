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
            Student s1 = new Student("John", "Smith", "jts", 90, 90);
            Student s2 = new Student("Mary", "Jones", "msj", 100, 90);
            Student s3 = new Student("Craig", "Abbot", "ca", 80, 100);
            Student s4 = new Student("Mary", "Jones", "msj", 90, 80);


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
            LbxOutput.Items.Add("");

            Student s5 = s2 + s4;
            LbxOutput.Items.Add(s5.ToString());
            LbxOutput.Items.Add(s2.ToString());
            LbxOutput.Items.Add(s4.ToString());
            LbxOutput.Items.Add("");

            int ave = (int)s5;
            LbxOutput.Items.Add(ave.RJ(13));
            LbxOutput.TopIndex = LbxOutput.Items.Count - 1;
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

        public Student(Student existingStudent)   // copy existing stduent to new student
        {
            FirstName = existingStudent.FirstName;
            LastName = existingStudent.LastName;
            Initials = existingStudent.Initials;
            MathAvg = existingStudent.MathAvg;
            SciAvg = existingStudent.SciAvg;
        }

        public override string ToString()
        {
            if (FirstName == null) return "* deleted *".LJ(13);
            return $"{(FirstName + " " + LastName).LJ(13)}: {Initials.RJ(5)}   Math Avg: {MathAvg.RJ(5)}    Sci Avg: {SciAvg.RJ(5)}";
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

        public static Student operator +(Student newStudent, Student oldStudent)
        {
            Student combinedStudent = new Student(newStudent);
            combinedStudent.MathAvg = (newStudent.MathAvg + oldStudent.MathAvg) / 2;
            combinedStudent.SciAvg = (newStudent.SciAvg + oldStudent.SciAvg) / 2;
            newStudent.NullStudent();
            oldStudent.NullStudent();
            return combinedStudent;
        }

        private void NullStudent()
        {
            FirstName = null;
            LastName = null;
            Initials = null;
            MathAvg = 0;
            SciAvg = 0;
        }

        public static explicit operator int(Student s)
        {
            return (s.MathAvg + s.SciAvg) / 2;
        }
    }






}
