using System;
namespace ezApiStrategy.Message
{
    public class TaxFiler
    {
        public int TaxFilerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CellNo { get; set; }
    }
    public class RecoveryQuestion : ModelBase
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class RecoverySetup : ModelBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        public IList<RecoveryQuestion> QuestionSetup { get; set; }
    }

}

