Feature: OpenBankAccountScenario1

Scenario Outline:T1. Create First Bank Account
	Given I am on the bank account creation screen
		And I enter initial balance of "<Initial Balance>"
		And I enter interest rate of "<Interest Rate>"
		And I click create account
		And I deposit "<Deposit>"
		And I add interest
		And I withdraw "<Withdraw>"
	When I get balance
	Then I check the balance with "<Total Balance>"

@T1 
    Examples: 
      | Initial Balance | Interest Rate | Deposit | Withdraw | Total Balance |
      | 2000            | 4.5           | 500     | 398.50   | 2214          |
      | 2850.60         | 4             | 500.75  | 398      | 3087.404      |