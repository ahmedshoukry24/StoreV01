const url = "https://localhost:44315/api/Product";
const errorObject = new Error("Network response wasn't ok!");

export const GetProducts = async () => {
  try {
    const response = await fetch(`${url}/Products`, {
      headers: {
        "Content-tyPe": "Application/Json",
      },
      method: "GET",
    });

    if (!response.ok) {
      throw errorObject;
    }

    const data = await response.json();

    return data;
  } catch (error) {
    console.log(`Error fetching products data: ${error}`);
    throw error;
  }
};

export const GetSearchProductChange = async (searchText) => {
  try {
    const response = await fetch(
      `${url}/SearchProductChange?searchText=${searchText}`,
      {
        headers: {
          "Content-Type": "application/json",
        },
        method:"GET"
      }
    );
    if(!response.ok){
        throw errorObject;
    }

    const result = await response.json();
    return result;

  } catch (error) {
    console.log(`Error fetching searched products: ${error}`);
    
  }
};
