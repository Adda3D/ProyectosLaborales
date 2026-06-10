const webpush = require('web-push');

exports.suscribe = async (req, res) => {
  const subscription = req.body.subscription;

    

    //create paylod
    // const payload = JSON.stringify({title: 'Node Js Push Notification' });

    const payload = JSON.stringify({
      title:req.body.title,
      // description:req.body.description,
      // icon:req.body.icon
    })
//send status 201
    res.status(201).json({})
    //pass the object into sendNotification
    webpush.sendNotification(subscription, payload).catch(err=> console.error(err));
}