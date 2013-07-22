Feature: Music Catalogue

Background: 
	Given I have the following items in the catalogue
		| Title                   | Artist     |
		| Dark Side of The Moon   | Pink Floyd |
		| Smells Like Teen Spirit | Nirvana    |
		| Live at the Acropolis   | Yanni      |

Scenario: Search by title
	When I search the title for the word 'moon'
	Then I should get 'Dark Side of The Moon' by 'Pink Floyd'

Scenario: Search without result
	When I search the title for the word 'baby'
	Then I should get a 404 response
