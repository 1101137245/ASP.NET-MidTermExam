using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class TxCourseService : ITxCourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void ExecuteTxMethod()
        {
            Course course1 = new Course();
            course1.Id = "AAA";
            course1.Name = "AAA";
            course1.Description = "0";
            CourseDao.AddCourse(course1);

            Course course2 = new Course();
            course2.Id = "BBB";
            course2.Name = "BBB";
            course2.Description = "0";
            CourseDao.AddCourse(course2);

            Course dbCourse = CourseDao.GetCourseById("AAA");
            dbCourse.Name = "XXX";
            CourseDao.UpdateCourse(dbCourse);

            throw new Exception("Get an exception");
        }

    }

}
