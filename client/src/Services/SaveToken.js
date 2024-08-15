export const SaveToken = (obj)=>{
    localStorage.setItem("token", obj.token);
    localStorage.setItem("expiryDate", obj.expiryDate);
}