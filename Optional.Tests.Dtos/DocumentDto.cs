using System;
using System.Collections.Generic;

namespace Optional.Tests.Dtos
{
    public class DocumentDto
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public Optional<IEnumerable<String>> Revisions { get; set; }
    }
}