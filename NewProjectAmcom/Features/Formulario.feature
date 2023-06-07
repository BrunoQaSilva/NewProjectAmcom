Feature: Formulario

@mytag
	Scenario: Fill out the first form
		Given I, navigate application
		When fill in the textbox of the form 
		| Nome  | SobreNome | Telefone  |
		| Bruno | Rocha     | 859999992 |
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 5 seconds
		And I Click Enviar Button
		And I wait for 5 seconds
		Then App return mensage confirm
		And I closed the popup


	Scenario: Select a color Blue
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I select to a color blue
		And I wait for 5 seconds

	Scenario: Select a color Yellow
		Given I, navigate application
		When I scroll the page down
		And I wait for 5 seconds
		And I click in Selector color
		And I wait for 2 seconds
		And I select to a color Yellow
		And I wait for 5 seconds









