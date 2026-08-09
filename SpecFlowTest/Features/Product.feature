Feature: Product
    Create a new product

	
    Scenario: Create product and verify the details
        Given I click the Product menu
        And I create product with following details
          | Name       | Description        | Price | ProductType |
          | Headphones3 | Noise cancellation | 300   | PERIPHARALS |
        When I click the Details link of the newly created product
        Then I see all the product details are created as expected