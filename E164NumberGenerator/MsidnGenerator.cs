using PhoneNumbers;
using System;
using System.Collections.Generic;

namespace E164NumberGenerator
{
    class MsidnGenerator
    {
        Random random = new Random();

        public string ValidMsisdn()
        {
            var randomMsisdn = ("+447" + random.Next(100000000, 999999999));

            while (numberValidator(randomMsisdn)[randomMsisdn] == false)
            {
                numberValidator(randomMsisdn);
            }

            return randomMsisdn;
        }

        public string InvalidMsisdn()
        {
            var randomMsisdn = ("+447" + random.Next(100000000, 999999999));

            while (numberValidator(randomMsisdn)[randomMsisdn] == true)
            {
                randomMsisdn = ("+447" + random.Next(100000000, 999999999));
                numberValidator(randomMsisdn);
            }

            return randomMsisdn;
        }

        public List<string> ValidMsisdnList(int numberOfMsisdns)
        {
            List<string> msisdns = new List<string>();

            while (msisdns.Count < numberOfMsisdns)
            {
                var randomMsisdn = ("+447" + random.Next(100000000, 999999999));
                if (numberValidator(randomMsisdn)[randomMsisdn] == true)
                {
                    msisdns.Add(randomMsisdn);
                }
            }

            return msisdns;
                       
        }

        public List<string> ValidTimeBasedMsisdnList(int numberOfMsisdns)
        {
            List<string> msisdns = new List<string>();

            while (msisdns.Count < numberOfMsisdns)
            {
                var randomMsisdn = DateTime.UtcNow.ToString("+447" + "ddMMHHmm" + random.Next(0, 9));
                if (numberValidator(randomMsisdn)[randomMsisdn] == true)
                {
                    msisdns.Add(randomMsisdn);
                }
            }

            return msisdns;

        }


        public Dictionary<string, bool> numberValidator(string msisdn)
        {
            var libPhoneNumber = PhoneNumberUtil.GetInstance();
            var phoneNumber = libPhoneNumber.ParseAndKeepRawInput(msisdn, null);

            var isValid = libPhoneNumber.IsValidNumber(phoneNumber)
                            && phoneNumber.CountryCodeSource ==
                            PhoneNumber.Types.CountryCodeSource.FROM_NUMBER_WITH_PLUS_SIGN;

            var internationalisedMsisdn = libPhoneNumber.Format(phoneNumber, PhoneNumberFormat.E164);

            Dictionary<string, bool> msisdnValid = new Dictionary<string, bool>();
            msisdnValid.Add(internationalisedMsisdn, isValid);

            return msisdnValid;
        }
    }
}
