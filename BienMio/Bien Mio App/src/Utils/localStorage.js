
const KEYS = {
  USER: `BM-USER`,
  TOKEN: `BM-TOKEN`
};



/**
 *
 * @param user
 */
export const saveUserDataLocal = ( user ) => {
  localStorage.setItem(`${KEYS.USER}`, JSON.stringify(user));
  localStorage.setItem(`${KEYS.TOKEN}`, user.token);
};


/**
 *
 * @return user 
 */
export const getUserDataLocal = () => {
  const userString = localStorage.getItem(`${KEYS.USER}`);
  const token = localStorage.getItem(`${KEYS.TOKEN}`);
  let user = null;
  if (userString && userString !== "null"){
    try {
      user = JSON.parse(userString)
    } catch (e) {
      console.log("Error getting user from local: ", e)
    }
  }
  return {...user, token};
};

export const cleanUserDataStorage = () => {
  for (let key in KEYS) {
    if (KEYS.hasOwnProperty(key)) {
      localStorage.removeItem(`${KEYS[key]}`);
    }
  }
};