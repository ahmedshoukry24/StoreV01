const  ValidateSignupForm=(userInputsObj)=>{

    const emailPattern = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
    const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;

    
    let errorsObject = {};
    //#region Validations
    // First Name
    if (userInputsObj.FirstName.length === 0) {
        errorsObject.firstNameError = "First name is required";
      }
      // Last Name
      if (userInputsObj.LastName.length === 0) {
        errorsObject.lastNameError = "Last name is required";
      }
      //username
      if (userInputsObj.UserName.length === 0) {
        errorsObject.usernameError = "Username is required";
      }
      // phone number
      if (userInputsObj.PhoneNumber.length === 0) {
        errorsObject.phoneNumberError = "Phone number is required";
      }
  
      // Email
      if (userInputsObj.Email.length === 0) {
        errorsObject.emailError = "Email is required";
      } else if (!emailPattern.test(userInputsObj.Email)) {
        errorsObject.emailError = "Email is not correct";
      }
      // Password
      if (userInputsObj.Password.length === 0) {
        errorsObject.passwordError = "Password is required";
      } else if (!passwordPattern.test(userInputsObj.Password)) {
        errorsObject.passwordError = "Password is not in format";
      }
  
      if (userInputsObj.ConfirmPassword !== userInputsObj.Password) {
        errorsObject.confirmPasswordError = "Password didn't match";
      }
  
      //#endregion

      return errorsObject;
}
export default ValidateSignupForm;