using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Lesson:IEntity
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
    }
}
