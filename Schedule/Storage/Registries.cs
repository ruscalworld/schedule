using Schedule.Components;
using Schedule.Storage;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Schedule {
    public class Registries {
        public static InstitutionRegistry Institutions = new InstitutionRegistry();
        public static GroupRegistry Groups = new GroupRegistry();
        public static CurriculumRegistry Curriculums = new CurriculumRegistry();
        public static RoomRegistry Rooms = new RoomRegistry();
        public static TeacherRegistry Teachers = new TeacherRegistry();
        public static LessonRegistry Lessons = new LessonRegistry();

        private static readonly Dictionary<string, Exportable> exportMap = new Dictionary<string, Exportable> {
            { "institutions", Institutions },
            { "curriculums", Curriculums },
            { "groups", Groups },
            { "rooms", Rooms },
            { "teachers", Teachers },
            { "lessons", Lessons },
        };

        public static void ExportAll(string path) {
            using (var memoryStream = new MemoryStream()) {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {
                    foreach (var key in exportMap.Keys) {
                        var registry = exportMap[key];
                        var file = archive.CreateEntry(key + ".json");

                        using (var fileStream = file.Open()) using (var writer = new StreamWriter(fileStream)) {
                            writer.Write(registry.ExportAll());
                        }
                    }
                }

                using (var fileStream = new FileStream(path, FileMode.OpenOrCreate)) {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }
        }

        public static void Import(string path) {
            using (var file = ZipFile.OpenRead(path)) {
                foreach (var key in exportMap.Keys) {
                    var entry = file.GetEntry(key + ".json");
                    if (entry == null) continue;

                    using (var reader = new StreamReader(entry.Open())) {
                        var registry = exportMap[key];
                        registry.Import(reader.ReadToEnd());
                    }
                }
            }
        }
    }

    public class AlreadyExistsException : Property.ValidationException {
        public AlreadyExistsException(string typeName, string propertyName) : base("Уже существует " + typeName + " с таким " + propertyName) { }
    }
}
