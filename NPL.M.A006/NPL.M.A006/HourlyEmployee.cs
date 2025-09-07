class HourlyEmployee : Employee
{
    public decimal Wage { get; set; }
    public int WorkingHours { get; set; }

    public HourlyEmployee(string ssn, string firstName, string lastName, DateTime birthDate, string phone, string email,
                          decimal wage, int workingHours)
        : base(ssn, firstName, lastName, birthDate, phone, email)
    {
        Wage = wage;
        WorkingHours = workingHours;
    }

    public override decimal CalculateEarnings()
    {
        return Wage * WorkingHours;
    }

    public override string ToString()
    {
        return $"Hourly Employee: {base.ToString()}, Earnings: {CalculateEarnings()}";
    }
}
