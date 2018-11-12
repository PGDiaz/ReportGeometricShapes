using Resources.Values;

namespace Resources.Contracts
{
    public interface ILocations
    {
        string GetTranslation(string keyText, Language language);
    }
}
