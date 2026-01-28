namespace UserDate{
    class Application
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Notes { get; set; }

        public Application(int Id, string CompanyName, string Position, DateTime ApplicationDate, ApplicationStatus Status, string Notes)
        {
            this.Id = Id;
            this.CompanyName = CompanyName;
            this.Position = Position;
            this.ApplicationDate = ApplicationDate;
            this.Status = Status;
            this.Notes = Notes;
        }
    }

    enum ApplicationStatus
    {
        Sent,
        Invited,
        Rejected,
        Accepted
    }
}