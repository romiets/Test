Feature: OpenBankAccountScenario1

Scenario: Create First Bank Account
	Given I am on the bank account creation screen
		And I enter initial balance of "2000"
		And I enter interest rate of "4.5"
		And I click create account
		And I deposit "500"
		And I add interest
		And I withdraw "398.50"
	When I get balance
	Then I check the balance with "2214"

	