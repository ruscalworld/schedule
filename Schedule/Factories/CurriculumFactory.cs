using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Factories {
    public class CurriculumFactory : Factory<Curriculum> {
        public Curriculum Create(Dictionary<string, object> data) {
            var rawDisciplines = data["disciplines"] as ListView.ListViewItemCollection;
            List<Discipline> disciplines = new List<Discipline>();

            foreach (ListViewItem rawDiscipline in rawDisciplines) {
                string name = rawDiscipline.Text;
                int credits = int.Parse(rawDiscipline.SubItems[2].Text);
                int complexity = int.Parse(rawDiscipline.SubItems[3].Text);

                string[] hoursParts = rawDiscipline.SubItems[1].Text.Split(' ');
                disciplines.Add(new Discipline(name, credits, complexity, new Dictionary<LessonType, int> {
                    { LessonType.Practical, int.Parse(hoursParts[0]) },
                    { LessonType.Lecture, int.Parse(hoursParts[1]) },
                    { LessonType.Laboratory, int.Parse(hoursParts[2]) },
                }));
            }

            return new Curriculum(data["name"] as string, disciplines);
        }
    }
}
