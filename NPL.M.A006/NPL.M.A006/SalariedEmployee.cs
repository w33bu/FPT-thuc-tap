class SalariedEmployee : Employee
{
    public decimal CommissionRate { get; set; }
    public decimal GrossSales { get; set; }
    public decimal BasicSalary { get; set; }

    public SalariedEmployee(string ssn, string firstName, string lastName, DateTime birthDate, string phone, string email,
                            decimal commissionRate, decimal grossSales, decimal basicSalary)
        : base(ssn, firstName, lastName, birthDate, phone, email)
    {
        CommissionRate = commissionRate;
        GrossSales = grossSales;
        BasicSalary = basicSalary;
    }

    public override decimal CalculateEarnings()
    {
        return BasicSalary + (CommissionRate * GrossSales);
    }

    public override string ToString()
    {
        return $"Salaried Employee: {base.ToString()}, Earnings: {CalculateEarnings()}";
    }
}
