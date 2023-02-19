import React, { useState, useCallback } from "react";

import Footer from "../components/Footer";
import NavBar from "../components/NavBar";
import ResultModal from "../components/ResultModal";

import Contact from "../utils/interfaces/Contact";
import Results from "../utils/interfaces/Results";

import { MainServices } from "../utils/Services";

const ContactUsScreen: React.FC<{}> = (): JSX.Element => {
    const [Name, setName] = useState("");
    const [Email, setEmail] = useState("");
    const [Phone, setPhone] = useState("");
    const [Message, setMessage] = useState("");

    const [Feedback, setFeedback] = useState("");
    const [FeedbackHeading, setFeedbackHeading] = useState("");

    const [Status, setStatus] = useState(false);

    const Services = new MainServices();

    const submitForm = () => {
        if (Email == "" || Name == "" || Phone == "" || Message == "") {
            handlePopUpLogic(true, "Error", "Please fill in all required fields.");
        } else if (!validateEmail(Email)) {
            handlePopUpLogic(true, "Error", "Please provide a valid email.");
        } else if (Phone.length < 10) {
            handlePopUpLogic(true, "Error", "Your phone number should be at least 10 chartacters long.");
        } else {
            const params: Contact = {} as Contact;

            params.Names = Name;
            params.Phone = Phone;
            params.Email = Email;
            params.Content = Message;

            handlePopUpLogic(true, "Processing", "Please wait . . .");

            try {
                Services.SubscribeUser(params)
                    .then((results: Results) => {
                        if (results.Error) {
                            handlePopUpLogic(true, "Error", results.ErrorDetail);
                        } else {
                            setName("");
                            setPhone("");
                            setEmail("");
                            setMessage("");
                            handlePopUpLogic(true, "Success", "Thank you.");
                        }
                    })
                    .catch((error: any) => {
                        handlePopUpLogic(true, "Error", error.message);
                    });
            } catch (error: any) {
                handlePopUpLogic(true, "Error", error.message);
            }
        }
    }

    const handlePopUpLogic = (status: boolean, heading: string, message: string) => {
        setStatus(status);
        setFeedback(message);
        setFeedbackHeading(heading);
    }

    const validateEmail = (email: string) => {
        return email.match(
            /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
    };


    const closeModal = useCallback(() => {
        setStatus(false);

    }, [Status])

    return <>
        <ResultModal status={Status} message={Feedback} heading={FeedbackHeading} closeModal={closeModal} />
        <NavBar />
        <div className="main-container" style={{ width: "80%", margin: "0 auto", padding: "2% 0 0 0" }}>
            <h4 className="container-heading">Contact Us</h4>

            <div className="contact-form">
                <fieldset className="form-group">
                    <label>Your Names</label>
                    <input type="text" placeholder="Your Names" value={Name} onChange={(e) => setName(e.target.value)} id="Name" name="Name" className="form-control" />
                </fieldset>
                <fieldset className="form-group">
                    <label>Your Email Address</label>
                    <input type="text" placeholder="Email Address" value={Email} onChange={(e) => setEmail(e.target.value)} id="Email" name="Email" className="form-control" />
                </fieldset>
                <fieldset className="form-group">
                    <label>Your Cellphone Number</label>
                    <input type="number" placeholder="Your Cellphone Number" value={Phone} onChange={(e) => setPhone(e.target.value)} id="Phone" name="Phone" className="form-control" />
                </fieldset>
                <fieldset className="form-group">
                    <label>Your Message</label>
                    <textarea className="form-control" id="Message" value={Message} name="Message" onChange={(e) => setMessage(e.target.value)} placeholder="Enter your message"></textarea>
                </fieldset>
                <button className="btn btn-primary" onClick={submitForm}>Submit</button>
            </div>
        </div>
        <Footer />
    </>
}

export default ContactUsScreen;
