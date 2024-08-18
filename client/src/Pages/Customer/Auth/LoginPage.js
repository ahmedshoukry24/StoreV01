import { useState } from "react";
import { useNavigate } from "react-router-dom";
import c from "./LoginPage.module.css";
import { SaveToken } from "../../../Services/SaveToken";
const LoginPage = () => {
  const [loginObject, setLoginObject] = useState({
    Email: "",
    Password: "",
  });

  const navigate = useNavigate();

  const onEmailChangeHandler = (event) => {
    setLoginObject((prevData) => {
      return { ...prevData, Email: event.target.value };
    });
  };

  const onPasswordChangeHandler = (event) => {
    setLoginObject((prevData) => {
      return { ...prevData, Password: event.target.value };
    });
  };

  const LoginService = async ({ Email, Password }) => {
    const url = "https://localhost:44315/api/Customer/Login";
    try {
      const response = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ Email, Password }),
      });
      if (!response.ok) return 0;

      const data = await response.json();

      return data;
    } catch (e) {
      return 0;
    }
  };

  const onSubmitHandler = async (event) => {
    event.preventDefault();

    const result = await LoginService(loginObject);
    if (result === 0) {
      console.log("Something went wrong!")
    }else{
      SaveToken(result);
      navigate('/Customer/CustomerHomePage');
    }
  };
  return (
    <div className={c.container}>
      <div>
        <div className={c.title}>Login</div>
        <form onSubmit={onSubmitHandler}>
          <div className={c.inputBox}>
            <span>Email</span>
            <input
              type="email"
              onChange={onEmailChangeHandler}
              value={loginObject.Email}
            />
          </div>
          <div className={c.inputBox}>
            <span>Password</span>
            <input
              type="password"
              onChange={onPasswordChangeHandler}
              value={loginObject.Password}
            />
          </div>
          <div>
            <button type="submit">Login</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default LoginPage;
