Feature: GetWeeklyAvailability
	As a user
	I want to get slot availability by concrete week
	So I could use this information to book a slot

@smoke
Scenario: Get weekly availability successfully
	Given I GET Weekly availability
	Then response status is OK

@smoke
Scenario Outline: Non-Monday day getting error correctness
	Given I GET Weekly availability for <nonMondayDay> day
	Then response status is Bad Request
	And response content is ""datetime must be a Monday""
Examples:
| nonMondayDay |
| 20180102     |
| 20180103     |
| 20180104     |
| 20180105     |
| 20180106     |
| 20180107     |

@smoke
Scenario Outline: Incorrect day parameter format error correctness
	Given I GET Weekly availability for <nonMondayDay> day
	Then response status is Bad Request
	And response content is ""datetime must be YYYYMMdd""
Examples:
| nonMondayDay |
| 2018010      |
| 15201801     |
| 10012018     | 

@smoke
Scenario Outline: Incorrect day parameter validation error correctness
	Given I GET Weekly availability for <nonMondayDay> day
	Then response status is Bad Request
	And response content is ""datetime must be a valid YYYYMMdd""
Examples:
| nonMondayDay |
| 2018010a     |
| 2018010!     |
| 20180000     |
| 20180001     |
| 20180100     |
| 00000101     |
| 20181301     |
| 20180132     |
| 20180229     |
| 20180431     |
| 20180631     |
| 20180931     |
| 20181131     |

#TBD tests

@smoke
#Test to check the data received is in correct format, not nullable and as per specification
#Simple to implement but quite time consuming
#Also in order to assure the result - connection to the DB is highly required
Scenario: Weekly availability data correctness
	Given TBD

@smoke
#Test to check the busy slots are in the range of working hours and and don't overlap lunch time
#Simple to implement but quite time consuming
Scenario: Busy slots data correctness
	Given TBD