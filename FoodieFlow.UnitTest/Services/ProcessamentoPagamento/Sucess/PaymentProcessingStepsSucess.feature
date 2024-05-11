@payment
Feature: Payment Processing As a customer I want to be able to process payments So that I can complete my purchase

  @successful
  Scenario: Successful payment processing
    Given I have a valid payment request
    When I call the payment request
    Then the payment should be processed correctly
    And the message should be sent correctly
    And the file should be written correctly to S3
