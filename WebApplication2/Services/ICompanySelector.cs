using WebApplication2.Model;

namespace WebApplication2.Services;

public interface ICompanySelector
{
    Company GetBiggestCompany();
}