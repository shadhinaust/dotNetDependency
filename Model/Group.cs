﻿using System;
using System.Collections.Generic;

namespace RestApi.Model
{
    public class Group: Auditor
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }

        public virtual ICollection<GroupRole> GroupRoles { get; set; }

        public Group()
        {
            this.UserGroups = new List<UserGroup>();
            this.GroupRoles = new List<GroupRole>();
            this.CreatedBy = this.ModifiedBy = "Dev";
            this.CreatedAt = this.ModifiedAt = DateTime.Now;
        }
    }
}