Feature: UBS Automation
	ubs.com test

# Global page tests
@tag1
Scenario: Check if menu appears - global page
	Given I navigate to the HomePage
	When I press Wealth Management button
	Then Wealth Management menu appears

@tag2
Scenario: Check if 'Your life goals' page opens - global page
	Given I navigate to the HomePage
	And I press Wealth Management button
	When I press Your life goals menu item
	Then Your life goals page appears

# "Select domicile" tests - switch to the local site of Finland, Denmark, Austria
@tag3
Scenario: Check if "Select domicile" menu appears - global page
	Given I navigate to the HomePage
	When I press Select domicile button
	Then Select domicile menu appears

@tag4
Scenario: Select domicile - Europe/Finland
	Given I navigate to the HomePage
	And I press Select domicile button
	When I select region 'Europe' and country 'Finland'
	Then I land on the 'Finland' HomePage

@tag5
Scenario: Select domicile - Europe/Denmark
	Given I navigate to the HomePage
	And I press Select domicile button
	When I select region 'Europe' and country 'Denmark'
	Then I land on the 'Denmark' HomePage

@tag6
Scenario: Select domicile - Europe/Austria
	Given I navigate to the HomePage
	And I press Select domicile button
	When I select region 'Europe' and country 'Austria'
	Then I land on the 'Austria' HomePage

# Below tests can be run on local sites - available sites: Austria, Denmark, France
@tag7
Scenario: Check if 'Your life goals' page opens - French page
	Given I navigate to the 'France' HomePage
	And I press Wealth Management button
	When I press Your life goals menu item
	Then Your life goals page appears

@tag8
Scenario: Check if 'Your life goals' page opens - Danish page
	Given I navigate to the 'Denmark' HomePage
	And I press Wealth Management button
	When I press Your life goals menu item
	Then Your life goals page appears

