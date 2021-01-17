Feature: HomePage Feature

Scenario Outline: verify signup
Given i am on home page
When i enter signup details as "<firstName>" "<lastNme>" "<phone>" "<country>" "<city>" "<emailAddress>" "<gender>" "<day>" "<time>" 
And uploaded "<file>"
When i submit form 
Then i should see "An error has occurred" message
Examples:
	| firstName | lastNme | phone | country | city | emailAddress  | gender | day    | time    | file     |
	| test      | test    | test  | test    | test | test@test.com | male   | sunday | morning | test.txt |
	

Scenario: verify search
Given i am on home page
When i search for "test"
Then i should see results as "test" "testcricket" "test (assessment)"