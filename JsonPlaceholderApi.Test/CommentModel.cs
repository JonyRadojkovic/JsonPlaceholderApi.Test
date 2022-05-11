using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPlaceholderApi.Test
{


    public class CommentModel
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }


}
