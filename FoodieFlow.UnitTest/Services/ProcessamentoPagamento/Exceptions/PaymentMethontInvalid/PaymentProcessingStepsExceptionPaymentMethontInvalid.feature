@payment
Feature: Payment Processing As a customer I want to be able to process payments So that I can complete my purchase with an invalid payment method

  @invalidPaymentMethod
  Scenario: Processing a payment request with an invalid payment method
    Given I have a payment request with an invalid payment method
    When I call the payment request with an invalid payment method
    Then an exception should be thrown with the  invalid payment method message "O método de pagamento é inválido."