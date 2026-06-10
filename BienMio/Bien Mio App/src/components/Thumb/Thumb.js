import React, { useState, useEffect } from 'react';

const Thumb = (props) =>{
  const [loading, setLoading] = useState(false);
  const [thumb, setThumb] = useState(undefined);
  const file = props?.file;
  useEffect(()=>{if(file){
    setLoading(true);
    let reader = new FileReader();

      reader.onloadend = () => {
        setThumb(reader.result)
      };
      setLoading(false);
      reader.readAsDataURL(file);
  }})

    if (!file) { return null; }

    return (
    <>
    {loading && (<p>loading...</p>)}
    {file &&(<img src={thumb}
      alt={file.name}
      className="img-thumbnail mt-2"
      height={200}
      width={200} />)}
    </>
    )

}

export default Thumb;