using System;
using System.Collections.Generic;
using IsuExtra.Entity;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        Lesson AddLesson(string lessonName, DateTime startTime, DateTime endTime, string teacher, int classRoom, int dayOfWeek);

        Lesson AddLessonToGroup(Lesson lesson, ExtraGroup group);
        Lesson AddLessonToGroup(Lesson lesson, OgnpGroup group);

        Lesson GetLesson(string lessonName, DateTime startTime, DateTime endTime, string teacher, int classRoom, int dayOfWeek);

        MegaFaculty GetMegaFaculty(MegaFacultyName name);
        MegaFaculty AddMegaFaculty(MegaFacultyName megaFacultyName, string ognpName);
        OgnpGroup AddOgnpThread(MegaFaculty megaFaculty, string ognpName, int maxStudentsOnThread);

        void AddOgnpToStudent(ExtraStudent student, OgnpGroup ognpName);
        void CloseOgnpCourse(ExtraStudent student, OgnpGroup group);
        void CloseAllOgnpCourse(ExtraStudent student);

        List<OgnpGroup> GetOgnpThreadsOnMegaFaculty(MegaFaculty megaFaculty);
        List<ExtraStudent> GetOgnpThreadStudents(MegaFaculty megaFaculty, OgnpGroup group);
        List<ExtraStudent> GetStudentsWithoutOgnp(ExtraGroup group);
        OgnpGroup GetOgnp(MegaFaculty megaFaculty, string ognpName);

        ExtraGroup GetGroup(ExtraGroupName groupName);
        ExtraStudent FindStudent(string name);
        ExtraGroup AddGroup(ExtraGroupName name, int maxOfStudentsInGroup);
        ExtraStudent AddStudent(ExtraGroup group, string name, int id);
    }
}