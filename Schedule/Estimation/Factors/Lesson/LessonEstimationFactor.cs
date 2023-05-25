using DataTypes;

namespace Schedule.Estimation {
    public abstract class LessonEstimationFactor : EstimationFactor<Lesson> {
        public abstract double GetVerdict(Lesson entity);
        public abstract double GetWeight();

        protected Discipline GetDiscipline(Lesson lesson) {
            Group group = Registries.Groups.GetEntity(lesson.GroupId);
            if (group == null) return null;

            Curriculum curriculum = Registries.Curriculums.GetEntity(group.CurriculumId);
            if (curriculum == null) return null;
            return curriculum.GetDisciplineByName(lesson.DisciplineName);
        }
    }
}
