using WebApplication2.Model;

namespace WebApplication2.Services;

public class CompanySelector : ICompanySelector
{
    private IConfiguration _configuration;
    public CompanySelector(IConfiguration config)
    {
        _configuration = config;
    }
    public Company GetBiggestCompany()
    {
        List<Company> companies = new List<Company>();

        foreach (var pair in _configuration.AsEnumerable())
        {
            if (pair.Key.StartsWith("company_"))
            {
                string company_name = pair.Key.Replace("company_", "");
                uint company_employees = Convert.ToUInt32(pair.Value);
                companies.Add(new Company(company_name, company_employees));
            }
        }

        return companies.MaxBy(company => company.Employees);
    }
}