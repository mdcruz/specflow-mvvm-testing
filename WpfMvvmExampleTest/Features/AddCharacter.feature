Feature: AddCharacter
	In order to see my favourite characters in Game of Thrones
	As a user
	I want to add the character's name, house name and status

	Scenario: Add new Game of Thrones character
		Given I have provided the following details:
			| Name       | House | Status |
			| Arya Stark | Stark | Alive  |
		When I add the character
		Then I should be able to see it in the character list

	Scenario: Verify that existing character should not be added again
		Given I have added the following character in my list:
			| Name             | House     | Status |
			| Tyrion Lannister | Lannister | Alive  |
		When I add the same character again
		Then I should see the message "Character already exists"
		And I should not be able to see it again in the character list

	Scenario Outline: Verify that any missing Character fields should be validated
		Given I have added the following character in my list:
			| Name   | House   | Status   |
			| <Name> | <House> | <Status> |
		When I add the character
		Then I should see the message "Please fill in all fields"

		Examples:
			| Name               | House | Status   |
			|                    | Stark | Deceased |
			| Daenerys Targaryen | null  |          |
			| Jon Snow           |       | null     |