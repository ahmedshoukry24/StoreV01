import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./SignupPage.css";
import ValidateSignupForm from "../../../Services/ValidateSignupForm";
import { SaveToken } from "../../../Services/SaveToken";

const SignupPage = () => {
  const emailPattern = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
  const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
  const navigate = useNavigate();
  const [error, setError] = useState({
    firstNameError: "",
    lastNameError: "",
    usernameError: "",
    phoneNumberError: "",
    emailError: "",
    passwordError: "",
    confirmPasswordError: "",
  });
  const [userInputsObj, setUserInputsObject] = useState({
    FirstName: "",
    LastName: "",
    UserName: "",
    Email: "",
    PhoneNumber: "",
    Password: "",
    ConfirmPassword: "",
  });

  // Submit method
  const onSubmitHandler = async (event) => {
    event.preventDefault();
    let errorsObject = ValidateSignupForm(userInputsObj);
    setError(errorsObject);

    if (Object.keys(errorsObject).length === 0) {
      userInputsObj.Discriminator = "Customer";
      let response = await fetch(
        "https://localhost:44315/api/Customer/Register",
        {
          method: "POST",
          body: JSON.stringify(userInputsObj),
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      if (!response.ok) {
        alert("Something Went Wrong!");
      } else {
        const data = await response.json();
        SaveToken(data);
        navigate("/Customer/CustomerHomePage");
        setUserInputsObject({
          FirstName: "",
          LastName: "",
          UserName: "",
          Email: "",
          PhoneNumber: "",
          Password: "",
          ConfirmPassword: "",
        });
      }
    }
  };

  //#region Handlers

  //#region First Name Handler
  const firstNameChangeHandler = (event) => {
    if (event.target.value.length === 0) {
      setError((prevData) => {
        return { ...prevData, firstNameError: "First Name is required" };
      });
    } else {
      setError((prevData) => {
        return { ...prevData, firstNameError: "" };
      });
    }

    setUserInputsObject((prevData) => {
      return { ...prevData, FirstName: event.target.value };
    });
  };

  //#endregion

  //#region Last Name Handler
  const lastNameChangeHandler = (event) => {
    if (event.target.value.length === 0) {
      setError((prevData) => {
        return { ...prevData, lastNameError: "Last Name is required" };
      });
    } else {
      setError((prevData) => {
        return { ...prevData, lastNameError: "" };
      });
    }
    setUserInputsObject((prevData) => {
      return { ...prevData, LastName: event.target.value };
    });
  };
  //#endregion

  //#region EmailHandler
  const emailChangeHandler = (event) => {
    if (event.target.value.length === 0) {
      setError((prevData) => {
        return { ...prevData, emailError: "Email is required" };
      });
    } else if (!emailPattern.test(event.target.value)) {
      setError((prevData) => {
        return { ...prevData, emailError: "Email is not correct" };
      });
    } else {
      setError((prevData) => {
        return { ...prevData, emailError: "" };
      });
    }

    setUserInputsObject((prevData) => {
      return { ...prevData, Email: event.target.value };
    });
  };
  //#endregion

  //#region username handler
  const userNameChageHandler = (event) => {
    if (event.target.value.length === 0) {
      setError((prevData) => {
        return { ...prevData, usernameError: "Username is required" };
      });
    } else {
      setError((prevData) => {
        return { ...prevData, usernameError: "" };
      });
    }

    setUserInputsObject((prevData) => {
      return { ...prevData, UserName: event.target.value };
    });
  };
  //#endregion

  //#region Phonenumber handler
  const phoneNumberChageHandler = (event) => {
    if (event.target.value.length === 0) {
      setError((prevData) => {
        return { ...prevData, phoneNumberError: "Phone number is required" };
      });
    } else {
      setError((prevData) => {
        return { ...prevData, phoneNumberError: "" };
      });
    }

    setUserInputsObject((prevData) => {
      return { ...prevData, PhoneNumber: event.target.value };
    });
  };
  //#endregion

  //#region password & confirm password
  const passwordChangeHandler = (event) => {
    if (event.target.value.length === 0) {
      setError((prevDate) => {
        return { ...prevDate, passwordError: "Password is required!" };
      });
    } else if (!passwordPattern.test(event.target.value)) {
      setError((prevDate) => {
        return { ...prevDate, passwordError: "Password is not in format!" };
      });
    } else {
      setError((prevDate) => {
        return { ...prevDate, passwordError: "" };
      });
    }

    setUserInputsObject((prevData) => {
      return { ...prevData, Password: event.target.value };
    });
  };

  const confirmPasswordChangeHandler = (event) => {
    if (event.target.value !== userInputsObj.Password) {
      setError((prevDate) => {
        return { ...prevDate, confirmPasswordError: "Password didn't match!" };
      });
    } else {
      setError((prevDate) => {
        return { ...prevDate, confirmPasswordError: "" };
      });
    }
    setUserInputsObject((prevData) => {
      return { ...prevData, ConfirmPassword: event.target.value };
    });
  };

  //#endregion

  //#endregion

  return (
    <div className="registeration-container">
      <div className="registeration-title">Registration</div>
      <form onSubmit={onSubmitHandler}>
        <div className="registreation-user-details">
          <div className="registration-input-box">
            <span className="input-box-details">First Name</span>
            <input
              type="text"
              placeholder="Enter your first name"
              onChange={firstNameChangeHandler}
              value={userInputsObj["FirstName"]}
            />
            {error.firstNameError && (
              <span className="error-span">{error.firstNameError}</span>
            )}
          </div>
          <div className="registration-input-box">
            <span className="input-box-details">Last Name</span>
            <input
              type="text"
              placeholder="Enter your last name"
              onChange={lastNameChangeHandler}
              value={userInputsObj["LastName"]}
            />
            {error.lastNameError && (
              <span className="error-span">{error.lastNameError}</span>
            )}
          </div>
          <div className="registration-input-box">
            <span className="input-box-details">Email</span>
            <input
              type="email"
              placeholder="Enter your Email"
              onChange={emailChangeHandler}
              value={userInputsObj["Email"]}
            />
            {error.emailError && (
              <span className="error-span">{error.emailError}</span>
            )}
          </div>
          <div className="registration-input-box">
            <span className="input-box-details">Username</span>
            <input
              type="text"
              placeholder="Enter your username"
              onChange={userNameChageHandler}
              value={userInputsObj["UserName"]}
            />
            {error.usernameError && (
              <span className="error-span">{error.usernameError}</span>
            )}
          </div>
          <div className="registration-input-box">
            <span className="input-box-details">phone Number</span>
            <input
              type="text"
              placeholder="Enter your phone number"
              onChange={phoneNumberChageHandler}
              value={[userInputsObj["PhoneNumber"]]}
            />
            {error.phoneNumberError && (
              <span className="error-span">{error.phoneNumberError}</span>
            )}
          </div>
          <div className="registration-input-box">
            <span className="input-box-details">Password</span>
            <input
              type="text"
              placeholder="Enter your password"
              onChange={passwordChangeHandler}
              value={userInputsObj["Password"]}
            />
            {error.passwordError && (
              <span className="error-span">{error.passwordError}</span>
            )}
          </div>
          <div className="registration-input-box">
            <span className="input-box-details">Confirm Password</span>
            <input
              type="text"
              placeholder="Confirm your password"
              onChange={confirmPasswordChangeHandler}
              value={userInputsObj["ConfirmPassword"]}
            />
            {error.confirmPasswordError && (
              <span className="error-span">{error.confirmPasswordError}</span>
            )}
          </div>
        </div>
        <div className="registration-gender-details">
          <input type="radio" name="gender" id="dot-1" />
          <input type="radio" name="gender" id="dot-2" />

          <div className="registration-gender-title">Gender</div>
          <div className="register-gender-category">
            <label htmlFor="dot-1">
              <span className="dot one"></span>
              <span className="gender">Male</span>
            </label>
            <label htmlFor="dot-2">
              <span className="dot two"></span>
              <span className="gender">Female</span>
            </label>
          </div>
        </div>
        <div className="registration-button">
          <button type="submit" value="register">
            Register
          </button>
        </div>
      </form>
    </div>
  );
};

export default SignupPage;
