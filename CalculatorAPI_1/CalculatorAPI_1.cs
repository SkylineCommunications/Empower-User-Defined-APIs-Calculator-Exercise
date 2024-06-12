/*
****************************************************************************
*  Copyright (c) 2024,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

05/06/2024	1.0.0.1		WVR, Skyline	Initial version
****************************************************************************
*/

namespace CalculatorAPI_1
{
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis;
    using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        /// <summary>
        /// The API trigger.
        /// </summary>
        /// <param name="engine">Link with SLAutomation process.</param>
        /// <param name="requestData">Holds the API request data.</param>
        /// <returns>An object with the script API output data.</returns>
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
        public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
        {
            // Split the request body by , to extract the numbers
            var numbers = requestData.RawBody.Split(',');

            // Validate the input
            if (numbers.Length != 2)
            {
                return new ApiTriggerOutput
                {
                    ResponseBody = "2 numbers need to be passed separated by a ,",
                    ResponseCode = (int)StatusCode.BadRequest,
                };
            }

            // Convert the parts to numbers
            if (!int.TryParse(numbers[0], out var number1))
            {
                return new ApiTriggerOutput
                {
                    ResponseBody = $"Could not parse {numbers[0]} to a number.",
                    ResponseCode = (int)StatusCode.BadRequest,
                };
            }

            if (!int.TryParse(numbers[1], out var number2))
            {
                return new ApiTriggerOutput
                {
                    ResponseBody = $"Could not parse {numbers[1]} to a number.",
                    ResponseCode = (int)StatusCode.BadRequest,
                };
            }

            var result = number1 + number2;

            return new ApiTriggerOutput
            {
                ResponseBody = result.ToString(),
                ResponseCode = (int)StatusCode.Ok,
            };
        }
    }
}