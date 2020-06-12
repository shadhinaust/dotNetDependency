using System;
using System.Runtime.Serialization;

namespace RestApi.Model
{
    [DataContract(IsReference = true)]
    public class UserGroup
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [DataMember]
        public short GroupId { get; set; }
        public virtual Group Group { get; set; }

        [DataMember]
        public Auditor Auditor { get; set; }

        public UserGroup()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}