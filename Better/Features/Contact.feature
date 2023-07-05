Feature: ContactTest

@BetterHelp @ContactTest
Scenario: Verify user should be able to submit the form successfully
	When I go to "Contact" page in Better Help
	Then Verify radio buttons are exist:
		| radioButtons                                                   |
		| I am a registered client and I need support.                   |
		| I am a current BetterHelp therapist and I need support.        |
		| I am a therapist interested in joining or a current applicant. |
		| I have a question about the service.                           |
		| I have a billing related question.                             |
		| I have a press-related question.                               |
		| I have a business-related inquiry.                             |
	When I click "I am a registered client and I need support." in the Contact page
	And I enter "~Talha" into "first-name" input box
	And I enter "~Turkyolu" into "last-name" input box
	And I enter "~turkyolutalha@gmail" into "email" input box
	And I enter "~Hey this is for automation test" into "message" input box
	And I click "Submit" button in the Contact page