const url = 'https://localhost:44315/api/Product/Products';

export const GetProducts=async ()=>{
    try{

        const response = await fetch(url,{
            headers:{
                'Content-tyPe': 'Application/Json',
            },
            method:'GET'
        });

        if(!response.ok){
            throw new Error('Network response wasn\'t ok!');
        }

        const data = await response.json();
        
        return data;

    }catch(error){
        console.log(`Error fetching products data: ${error}`);
        throw error;
    }
}