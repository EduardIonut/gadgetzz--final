using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.UnitTests.Builders
{
    public class AddressBuilder
    {
        private Address _address;
        public string TestStreet => "Str. Copou";
        public string TestCity => "Iasi";
        public string TestState => "Iasi";
        public string TestCountry => "Romania";
        public string TestZipCode => "662426";

        public AddressBuilder()
        {
            _address = WithDefaultValues();
        }
        public Address Build()
        {
            return _address;
        }
        public Address WithDefaultValues()
        {
            _address = new Address(TestStreet, TestCity, TestState, TestCountry, TestZipCode);
            return _address;
        }
    }
}
