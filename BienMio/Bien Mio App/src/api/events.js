import axios from "axios"
import { config } from "../settings"


export const getAllEvents = (token) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/events`,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        }
			)
			.then((res) => {
				const data = res.data;

				resolve(data.data);
			})
			.catch((err) => {
				reject(err)
			});
	});
};



