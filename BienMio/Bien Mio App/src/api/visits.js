import axios from "axios"
import { config } from "../settings"


export const getAllVisits = (token) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/visits`,
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

export const getVisit = (token, id) => {
  return new Promise((resolve, reject) => {
		axios
      .get(
				`${config.baseAPIUrl}/visits/${id}`,
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

export const editVisit = (id, data, token) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/visits/${id}`,
				data,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
						'Content-Type': 'multipart/form-data'
          },
        }
			)
			.then((res) => {
				const data = res.data;
				resolve({...data.data});
			})
			.catch((err) => {
				reject(err)
			});
	});
};

export const createVisit = (data, token) => {
  return new Promise((resolve, reject) => {
		axios
			.post(
				`${config.baseAPIUrl}/visits/`,
				data,
        {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        }
			)
			.then((res) => {
				const data = res.data;
				resolve({...data.data});
			})
			.catch((err) => {
				reject(err)
			});
	});
};