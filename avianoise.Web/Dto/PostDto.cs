﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public int? PostId { get; set; }

        public string Text { get; set; }

        public bool IsPublished { get; set; }

        public DateTime AddedDate { get; set; }

        public List<PostDto> Posts { get; set; }
    }
}
