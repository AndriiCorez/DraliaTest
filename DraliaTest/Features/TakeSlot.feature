Feature: TakeSlot
	As user
	I want to be able to take available time slot
	So it will be booked for a visit

@regression
Scenario: Take slot successfully
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 10:10:00" | "2018-03-05 10:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is OK
	#Step with asserting if the slot is taken on the DB side is missed

@regression
Scenario: Taking slot without a start timestamp
	Given I take the follwoing slot
	| Start | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| ""    | "2018-01-29 09:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot without an end timestamp
	Given I take the follwoing slot
	| Start                 | End | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 09:10:00" | ""  | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot with invalid timestamps
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-33-45 59:10:72" | "2018-31-49 29:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	Then response status is Bad Request
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot for 11 minutes 
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 09:10:00" | "2018-01-29 09:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	Then response status is Bad Request
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot for 9 minutes 
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 09:10:00" | "2018-01-29 09:19:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	Then response status is Bad Request
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot with changed request body structure
	Given I take the follwoing slot with errors
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 09:10:00" | "2018-03-05 09:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	And response content is ""Valid slot.Start required""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot without patient names
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name | SecondName | Email          | Phone       |
	| "2018-03-05 09:10:00" | "2018-03-05 09:20:00" | N/A      |      |            | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot without patient email
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email | Phone       |
	| "2018-03-05 09:10:00" | "2018-03-05 09:20:00" | N/A      | AutoName | AutoSurname |       | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot without patient phone number
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone |
	| "2018-03-07 09:10:00" | "2018-03-07 09:20:00" | N/A      | AutoName | AutoSurname | auto@email.com |       |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot with incorrect patient names format
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name | SecondName | Email          | Phone       |
	| "2018-03-07 09:10:00" | "2018-03-07 09:20:00" | N/A      | a123 | !@a        | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot with incorrect patient Email format
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email | Phone |
	| "2018-03-07 09:10:00" | "2018-03-07 09:20:00" | N/A      | AutoName | AutoSurname | !a2   |       |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot with incorrect patient Phone format
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-07 09:10:00" | "2018-03-07 09:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot from past dates
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2017-12-04 09:10:00" | "2017-12-04 09:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
Scenario: Taking slot with end timestamp earlier than start timestamp
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-07 09:10:00" | "2018-03-07 09:00:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
#TBD needs connection to the DB to book a slot from the DB for particular date
Scenario: Taking Busy slot
	Given TBD

@regression
#TBD needs connection to the DB to book a slot from the DB for particular date
Scenario: Taking slot during lunch break
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 13:10:00" | "2018-03-05 13:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed

@regression
#TBD needs connection to the DB to book a slot from the DB for particular date
Scenario: Taking slot out of working hours
	Given I take the follwoing slot
	| Start                 | End                   | Comments | Name     | SecondName  | Email          | Phone       |
	| "2018-03-05 23:10:00" | "2018-03-05 23:20:00" | N/A      | AutoName | AutoSurname | auto@email.com | 34987654321 |
	Then response status is Bad Request
	#Correct content text to be specified once TakeSlot POST blocker bug is resolved, so that more explarotary tests can be done 
	#OR specs about expected behaviour are available
	And response content is ""Some error text""
	#Step with asserting if the slot is NOT taken on the DB side is missed


