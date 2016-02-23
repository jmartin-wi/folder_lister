using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folder_Lister
{
    class DTO
    {

        public class cboItem
        {
            public string Name { get; set; }
            public string Id { get; set; }

            public cboItem(string name, string id)
            {
                Name = name;
                Id = id;
            }
        }

        public class DocTree
        {
            public string TreeId { get; set; }
            public string TreeName { get; set; }
            public string TreeCreateDate { get; set; }
            public string TreeComment { get; set; }
            public string TreeType { get; set; }
            public string TreeRoot { get; set; }
            public string LeafType { get; set; }
            public string LeafName { get; set; }
            public string LeafPath { get; set; }
            public string LeafSize { get; set; }
            public string LeafId { get; set; }
            public string LeafCategory { get; set; }
            public string LeafSubCategory { get; set; }
            public string LeafCreated { get; set; }
            public string LeafCreatUser { get; set; }
            public string LeafComment { get; set; }
            public string LeafViewed { get; set; }
            public string LeafLocation { get; set; }
        }

    }
}
